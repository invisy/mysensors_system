class AuthService {
    async login(login, password, remember) {
        const data = { login: login, password: password };
        const response = await fetch("api/account/login", {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        
        if(response.ok)
        {
            let responseObject = await response.json();
            if (responseObject.token) {
                if(remember)
                    localStorage.setItem("user", JSON.stringify(responseObject));
                else
                    sessionStorage.setItem("user", JSON.stringify(responseObject));
            }
            return response.ok;
        }
        else if(response.status === 400 || response.status === 401)
            throw await response.text()
        else
            throw "Unknown error";
    }

    logout() {
        localStorage.removeItem("user");
        sessionStorage.removeItem("user");
    }

    async register(firstname, lastname, email, password) {
        const data = {name: firstname, surname: lastname, email: email, password: password };
        const response = await fetch("api/account/register", {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if(response.ok)
            return await response.json();
        else if(response.status === 400 || response.status === 422)
            throw await response.text()
        else
            throw "Unknown error";
    }

    getCurrentUser() {
        const userLocalStorage = JSON.parse(localStorage.getItem('user'));
        return userLocalStorage ? userLocalStorage: JSON.parse(sessionStorage.getItem('user'));
    }
}

export default new AuthService();