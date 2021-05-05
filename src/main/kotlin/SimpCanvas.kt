import com.ccfraser.muirwik.components.*
import com.ccfraser.muirwik.components.button.MButtonVariant
import com.ccfraser.muirwik.components.button.mButton
import com.ccfraser.muirwik.components.button.mButtonGroup
import com.ccfraser.muirwik.components.button.mIconButton
import com.ccfraser.muirwik.components.card.*
import com.ccfraser.muirwik.components.form.mFormLabel
import com.ccfraser.muirwik.components.transitions.mCollapse
import kotlinx.browser.window
import kotlinx.css.*
import kotlinx.css.properties.*
import kotlinx.html.js.onClickFunction
import kotlinx.html.js.onMouseDownFunction
import kotlinx.html.js.onMouseMoveFunction
import kotlinx.html.js.onMouseUpFunction
import org.w3c.dom.CanvasRenderingContext2D
import org.w3c.dom.HTMLCanvasElement
import org.w3c.dom.HTMLElement
import org.w3c.dom.events.Event
import react.*
import react.dom.div
import styled.css
import styled.styledCanvas
import styled.styledDiv

class SimpCanvas : RComponent<SimpCanvasProps, SimpCanvasState>() {
    var penDown: Boolean = false
    private var expanded = false
    val scale: Int
    get() {
        return props.displaySize.width / props.fileSize.width
    }

    override fun RBuilder.render() {
        styledCanvas {
            css {
//                width = props.displaySize.width.px
//                height = props.displaySize.height.px
                width = LinearDimension.auto
                height = 100.vh
                border = "1px solid #000000"
                backgroundColor = Color.yellow
                put("image-rendering","pixelated")
                put("image-rendering","-moz-crisp-edges")
            }

            attrs {
                width = "${props.fileSize.width}px"
                height = "${props.fileSize.height}px"

                onClickFunction = {
                    val canvas:HTMLCanvasElement = it.target.unsafeCast<HTMLCanvasElement>()
                    val ctx = canvas.getContext("2d") as CanvasRenderingContext2D

                    ctx.moveTo(0.0,0.0)
                    ctx.lineTo(props.fileSize.width.toDouble(), props.fileSize.height.toDouble())
                    ctx.stroke()
                }

                onMouseDownFunction = {
                    penDown = true
                }

                onMouseUpFunction = {
                    penDown = false
                }

                onMouseMoveFunction = {
                    disectEvent<HTMLCanvasElement,MouseEvent<HTMLCanvasElement>>(it) {
                        val rect = target.getBoundingClientRect()

                        setState {
                            x = (event.clientX as Int) - rect.left.toInt()
                            y = (event.clientY as Int) - rect.top.toInt()

                            val displayPoint = DisplayPoint(state.x,state.y)
                            val filePoint = this@SimpCanvas.displayPointToFilePoint(displayPoint)

                            if (penDown) {
                                val ctx = target.getContext("2d") as CanvasRenderingContext2D

                                ctx.fillRect(filePoint.x.toDouble(),filePoint.y.toDouble(),1.0,1.0)
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
    var displaySize: DisplaySize
}

external interface SimpCanvasState : RState {
    var x: Int
    var y: Int
}

fun RBuilder.simpCanvas(handler: SimpCanvasProps.() -> Unit): ReactElement {
    return child(SimpCanvas::class) {
        this.attrs(handler)
    }
}