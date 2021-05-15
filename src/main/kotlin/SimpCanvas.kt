import kotlinx.css.*
import kotlinx.html.js.*
import org.w3c.dom.CanvasRenderingContext2D
import org.w3c.dom.HTMLCanvasElement
import org.w3c.dom.HTMLElement
import org.w3c.dom.events.Event
import react.*
import react.dom.findDOMNode
import styled.css
import styled.styledCanvas

class SimpCanvas : RComponent<SimpCanvasProps, SimpCanvasState>() {
    var penDown: Boolean = false
    private var expanded = false
    val element: HTMLCanvasElement by kotlin.lazy {
        findDOMNode(this) as HTMLCanvasElement
    }

    val scale: Double
    get() {
        return element.getBoundingClientRect().height / props.fileSize.width
    }


    override fun RBuilder.render() {
        styledCanvas {
            css {
//                width = props.displaySize.width.px
//                height = props.displaySize.height.px
//                width = 100.pct
                height = 100.pct
//                border = "1px solid #000000"
                backgroundColor = Color.yellow
                put("image-rendering","pixelated")
                put("image-rendering","-moz-crisp-edges")
            }

            attrs {
                width = "${props.fileSize.width}px"
                height = "${props.fileSize.height}px"

                onMouseDownFunction = {
                    penDown = true
                    disectEvent<HTMLCanvasElement,MouseEvent<HTMLCanvasElement>>(it) {
                        val rect = target.getBoundingClientRect()

                        setState {
                            dLast = DisplayPoint(
                                (event.clientX as Int) - rect.left.toInt(),
                                (event.clientY as Int) - rect.top.toInt()
                            )
                        }
                    }
                }

                onMouseUpFunction = {
                    penDown = false
                }

                onMouseMoveFunction = {
                    disectEvent<HTMLCanvasElement,MouseEvent<HTMLCanvasElement>>(it) {
                        val rect = target.getBoundingClientRect()

                        if (penDown) {
                            val dCurrent = DisplayPoint((event.clientX as Int) - rect.left.toInt(),(event.clientY as Int) - rect.top.toInt())

                            val fLast = displayPointToFilePoint(state.dLast)
                            val fCurrent = displayPointToFilePoint(dCurrent)

                            val ctx = target.getContext("2d") as CanvasRenderingContext2D

                            ctx.imageSmoothingEnabled = false

                            ctx.translate(0.5,0.5)
                            ctx.strokeStyle = "#FF0000"
                            ctx.beginPath()
                            ctx.moveTo(fLast.x,fLast.y)
                            ctx.lineTo(fCurrent.x,fCurrent.y)
                            ctx.stroke()
                            ctx.translate(-0.5,-0.5)

                            setState {
                                dLast = DisplayPoint(
                                    (event.clientX as Int) - rect.left.toInt(),
                                    (event.clientY as Int) - rect.top.toInt()
                                )
                            }
                        }
                    }
                }
            }
        }
    }
}



fun <T : HTMLElement,E : SyntheticEvent<T>> disectEvent(event: Event, handler: TargetAndEvent<T,E>.() -> Unit) {
    handler(TargetAndEvent(
        event.target.unsafeCast<T>(),
        event.unsafeCast<E>()
    ))
}

data class TargetAndEvent<T : HTMLElement,E : SyntheticEvent<T>> (
    val target: T,
    val event: E
)

external interface SimpCanvasProps : RProps {
    var fileSize: FileSize
}

external interface SimpCanvasState : RState {
    var dLast: DisplayPoint
}

fun RBuilder.simpCanvas(handler: SimpCanvasProps.() -> Unit): ReactElement {
    return child(SimpCanvas::class) {
        this.attrs(handler)
    }
}