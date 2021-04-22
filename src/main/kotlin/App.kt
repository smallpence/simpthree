import react.RBuilder
import react.RComponent
import react.RProps
import react.RState
import react.dom.h1

class App : RComponent<RProps, RState>() {
    override fun RBuilder.render() {
        h1 {
            + "SIMP III"
        }

        simpCanvas { }
    }

}