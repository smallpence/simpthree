import org.w3c.dom.CanvasRenderingContext2D

fun CanvasRenderingContext2D.moveTo(x: Int, y: Int) {
    moveTo(x.toDouble(), y.toDouble())
}

fun CanvasRenderingContext2D.lineTo(x: Int, y: Int) {
    lineTo(x.toDouble(), y.toDouble())
}