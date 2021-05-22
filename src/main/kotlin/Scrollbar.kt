import com.ccfraser.muirwik.components.styles.Theme
import kotlinx.css.*
import react.*
import react.dom.button
import styled.css
import styled.styledButton
import styled.styledDiv

class Scrollbar : RComponent<ScrollbarProps, RState>() {
    override fun RBuilder.render() {
        styledDiv {
            styledButton {
                css {
                    rounded()
                    highlight()

                    width =  if (props.horizontal) 100.px else 28.px
                    height = if (props.horizontal) 28.px else 100.px
                }
            }
        }
    }

}

external interface ScrollbarProps : RProps {
    var horizontal: Boolean
}

fun RBuilder.scrollBar(handler: ScrollbarProps.() -> Unit): ReactElement {
    return child(Scrollbar::class) {
        this.attrs(handler)
    }
}