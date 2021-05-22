import kotlinx.css.*

fun CSSBuilder.rounded() {
    this.apply {
        borderRadius = 5.px
    }
}

fun CSSBuilder.highlight() {
    this.apply {
        backgroundColor = Color.aquamarine
    }
}