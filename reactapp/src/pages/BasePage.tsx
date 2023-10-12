import { useState } from "react"
import UserLoginForm from "../components/UserLoginForm"
import NewUserForm from "../components/NewUserForm"

function BasePage() {

    const [user, setUser] = useState(null)
    return (
        <>
            <UserLoginForm/>
            <NewUserForm/>
        </>
    )
}

export default BasePage