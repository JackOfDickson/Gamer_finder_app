
export function useCookies() {
    function setCookie(name: string, value: string, days: number) {
        const expires = new Date()
        expires.setTime(expires.getTime() + days * 24 * 60 * 60 * 1000)
        document.cookie = `${name}=${value};expires=${expires.toUTCString()};path=/`
    }

    function getCookie(name: string) {
        const cookieValue = document.cookie.match(
            "(^|;) ?" + name + "=([^;]*)(;|$)"
        )
        return cookieValue ? cookieValue[2] : null
    }

    return { setCookie, getCookie }
}
