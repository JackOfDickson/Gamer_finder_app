import newUserInfo from "../types/newUserInfo"
import loginInfo from "../types/loginInfo"

const baseurl = "http://localhost:5184"

export const registerUser = (newUserInfo: newUserInfo) => {
    return fetch(baseurl + "/api/users", 
            {
                method: 'POST',
                body: JSON.stringify(newUserInfo),
                headers: {'Content-Type': 'application/json'}
            }
        )
}

export const loginUser = async (loginInfo: loginInfo) => {
    return fetch(baseurl + "/api/users/login", 
    {
        method: 'POST',
        body: JSON.stringify(loginInfo),
        headers: {'Content-Type': 'application/json'}
    }).then(response => { 
        if (response.ok) {
            return response.json()
        }
        else throw Error("Unauthorised")
    })
    .catch(error => console.log(error))
}