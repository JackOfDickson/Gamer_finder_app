import newUserInfo from "../types/newUserInfo"

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