import com.ccfraser.muirwik.components.MSliderOrientation
import com.ccfraser.muirwik.components.mSlider
import com.ccfraser.muirwik.components.orientation
import kotlinx.css.*
import react.*
import react.dom.button
import styled.css
import styled.styledDiv

class SimpEditor : RComponent<SimpEditorProps, RState>() {
    override fun RBuilder.render() {
        styledDiv {
            css {
                height = 100.pct
                display = Display.grid
                gridTemplateAreas = GridTemplateAreas("""
                    "image       vertslider"
                    "horzslider ."
                """)
                gridTemplateColumns = GridTemplateColumns("auto 28px")
                gridTemplateRows = GridTemplateRows("auto 28px")
            }
            styledDiv {
                css {
                    put("grid-area","image")
                    display = Display.flex
                    justifyContent = JustifyContent.center
                }
                simpCanvas { fileSize = props.fileSize }
            }
            scrollBar {
                horizontal = false
                range = 50
                length = 10
            }
            scrollBar {
                horizontal = true
                range = 50
                length = 10
            }
        }

    }
}

external interface SimpEditorProps : RProps {
    var fileSize: FileSize
}

fun RBuilder.simpEditor(handler: SimpEditorProps.() -> Unit): ReactElement {
    return child(SimpEditor::class) {
        this.attrs(handler)
    }
}