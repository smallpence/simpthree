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

fun SimpCanvas.displayPointToFilePoint(displayPoint: DisplayPoint): FilePoint {
    return FilePoint((displayPoint.x / scale).toInt(), (displayPoint.y / scale).toInt())
}

data class FilePoint (
    val x: Int,
    val y: Int
)

//fun SimpCanvas.filePointToDisplayPoint(filePoint: FilePoint): DisplayPoint {
//    return DisplayPoint(filePoint.x * scale, filePoint.y * scale)
//}

