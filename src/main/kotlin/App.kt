import com.ccfraser.muirwik.components.*
import com.ccfraser.muirwik.components.styles.Breakpoint
import kotlinx.css.*
import react.RBuilder
import react.RComponent
import react.RProps
import react.RState
import react.dom.div
import react.dom.h1
import styled.css
import styled.styledDiv
import styled.styledP

class App : RComponent<RProps, RState>() {
    override fun RBuilder.render() {
        styledDiv {
            css {
                display = Display.grid
                gridTemplateRows = GridTemplateRows(50.px, LinearDimension.auto)
                gridTemplateColumns = GridTemplateColumns.auto
                height = 100.vh
                overflow = Overflow.hidden
            }
            styledDiv {
                css {
                    gridRow= GridRow("1")
                    gridColumn = GridColumn("1")
                    backgroundColor = Color.aqua
                }
//                styledP {
//                    css {
//                        height = 100.pct
//                    }
//                    + "hello"
//                }
            }
            styledDiv {
                css {
                    gridRow = GridRow("2")
                    gridColumn = GridColumn("1")
                    backgroundColor = Color.red
                }
                simpCanvas {
                    fileSize = FileSize(100,100)
                }
            }
        }
    }
}