import kotlinx.css.*
import kotlinx.html.js.onMouseDownFunction
import kotlinx.html.js.onMouseMoveFunction
import kotlinx.html.js.onMouseUpFunction
import org.w3c.dom.HTMLButtonElement
import org.w3c.dom.HTMLCanvasElement
import org.w3c.dom.HTMLDivElement
import org.w3c.dom.get
import react.*
import react.dom.div
import react.dom.findDOMNode
import styled.css
import styled.styledButton
import styled.styledDiv

class Scrollbar : RComponent<ScrollbarProps, ScrollbarState>() {
    val divElement: HTMLDivElement by kotlin.lazy {
        findDOMNode(this) as HTMLDivElement
    }
    val buttonElement : HTMLButtonElement by kotlin.lazy {
        divElement.children.get(1) as HTMLButtonElement
    }

    val barSize: Int get() {
        return (props.length * 100 / (props.range))
    }
    val horizontal get() = props.horizontal
    val vertical get() =  !horizontal
    val elementRect get() = divElement.getBoundingClientRect()

    override fun RBuilder.render() {
        styledDiv {
            css {
                display = Display.flex

                if (vertical) flexDirection = FlexDirection.column
            }

            attrs {
                onMouseMoveFunction = {
                    disectEvent<HTMLCanvasElement,MouseEvent<HTMLCanvasElement>>(it) {
                        if (state.mouseDown) {
                            setState {
                                buttonOffset = if (horizontal)
                                    ((event.clientX as Int - (cursorOffset ?: 0) - elementRect.left.toInt()) * 100) / elementRect.width.toInt()
                                else
                                    ((event.clientY as Int - (cursorOffset ?: 0) - elementRect.top.toInt()) * 100) / elementRect.height.toInt()

                                buttonOffset = (0..100).clamp(buttonOffset!!)
                            }
                        }
                    }
                }
            }

            styledDiv {
                css {
                    if (horizontal) {
                        width = (state.buttonOffset ?: 0).pct
                    } else {
                        height = (state.buttonOffset ?: 0).pct
                    }
                }
            }

            styledButton {
                css {
                    rounded()
                    highlight()

                    if (horizontal) {
                        width =   barSize.pct
                        height =  100.pct
                    } else {
                        width =  100.pct
                        height = barSize.pct
                    }
                }
                attrs {
                    onMouseDownFunction = {
                        disectEvent<HTMLCanvasElement,MouseEvent<HTMLCanvasElement>>(it) {
                            setState {
                                cursorOffset =
                                    if (horizontal) event.clientX as Int - buttonElement.getBoundingClientRect().left.toInt()
                                    else            event.clientY as Int - buttonElement.getBoundingClientRect().top.toInt()
                                mouseDown = true
                            }
                        }
                    }

                    onMouseUpFunction = {
                        disectEvent<HTMLCanvasElement,MouseEvent<HTMLCanvasElement>>(it) {
                            setState {
                                mouseDown = false
                            }
                        }
                    }
                }
            }
        }
    }

}

external interface ScrollbarProps : RProps {
    var horizontal: Boolean // whether bar is horizontal (else vertical)
    var range: Int // range of bar
    var length: Int // length of bar

    var onUpdate: (Int) -> Unit
}

external interface ScrollbarState: RState {
    var cursorOffset: Int?
    var buttonOffset: Int?
    var mouseDown: Boolean
    var pos: Int
}

fun RBuilder.scrollBar(handler: ScrollbarProps.() -> Unit): ReactElement {
    return child(Scrollbar::class) {
        this.attrs(handler)
    }
}