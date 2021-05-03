data class DisplaySize (
    val width:  Int,
    val height: Int
)

data class FileSize (
    val width:  Int,
    val height: Int
)

data class DisplayPoint (
    val x: Int,
    val y: Int
)

data class FilePoint (
    val x: Int,
    val y: Int
)

fun FilePoint.toDisplayPoint(displaySize: DisplaySize): DisplayPoint {
    return DisplayPoint(x * displaySize.width, x * displaySize.height)
}

fun

