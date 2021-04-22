import kotlinx.browser.document
import kotlinx.css.px
import kotlinx.html.canvas
import kotlinx.html.js.onClickFunction
import org.w3c.dom.CanvasRenderingContext2D
import org.w3c.dom.HTMLCanvasElement
import org.w3c.dom.RenderingContext
import react.*
import react.dom.canvas

class SimpCanvas : RComponent<RProps, RState>() {
    override fun RBuilder.render() {
        canvas {
            attrs.width = "100.px"
            attrs.height = "100.px"

            attrs {
                onClickFunction = {
                    val canvas:HTMLCanvasElement = it.target.unsafeCast<HTMLCanvasElement>()
                    val ctx = canvas.getContext("2d") as CanvasRenderingContext2D

                    ctx.moveTo(0.0,0.0)
                    ctx.lineTo(100.0,100.0)
                    ctx.stroke()
                }
            }


        }
    }
}

fun RBuilder.simpCanvas(handler: RProps.() -> Unit): ReactElement {
    return child(SimpCanvas::class) {
        this.attrs(handler)
    }
}