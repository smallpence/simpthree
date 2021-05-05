import com.ccfraser.muirwik.components.mContainer
import com.ccfraser.muirwik.components.styles.Breakpoint
import react.RBuilder
import react.RComponent
import react.RProps
import react.RState
import react.dom.h1

class App : RComponent<RProps, RState>() {
    override fun RBuilder.render() {
        simpCanvas {
            fileSize = FileSize(100,100)
            displaySize = DisplaySize(800,800)
        }
//        mContainer(maxWidth = Breakpoint.xl) {
//
//        }
    }
}