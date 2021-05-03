import kotlinx.browser.document
import kotlinx.css.px
import kotlinx.html.canvas
import kotlinx.html.js.onClickFunction
import kotlinx.html.js.onMouseDownFunction
import kotlinx.html.js.onMouseMoveFunction
import kotlinx.html.js.onMouseUpFunction
import org.w3c.dom.CanvasRenderingContext2D
import org.w3c.dom.HTMLCanvasElement
import org.w3c.dom.RenderingContext
import react.*
import react.dom.canvas

class SimpCanvas : RComponent<SimpCanvasProps, SimpCanvasState>() {
    var penDown: Boolean = false

    override fun RBuilder.render() {
        canvas {
            attrs.width = "100.px"
            attrs.height = "100.px"

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

                            val displayPoint = DisplayPoint(x,y)
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

fun RBuilder.simpCanvas(handler: RProps.() -> Unit): ReactElement {
    return child(SimpCanvas::class) {
        this.attrs(handler)
    }
}