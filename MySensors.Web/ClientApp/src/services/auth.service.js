class AuthService {
    async login(login, password) {
        const data = { login: login, password: password };
        const response = await fetch("api/account/login", {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const json = await response.json();
        console.log('Успех:', JSON.stringify(json));
    }

    logout() {
        localStorage.removeItem("user");
    }

    /*register(username, email, password) {
        return axios.post(API_URL + "signup", {
            username,
            email,
            password
        });
    }*/

    getCurrentUser() {
        return JSON.parse(localStorage.getItem('user'));;
    }
}

export default new AuthService();