import authHeader from './auth-header'

class SensorsService {
    async getSensors() {
        let auth = authHeader();
        const response = await fetch("/api/sensors", {
            headers: {
                'Content-Type': 'application/json',
                ...auth
            }
        });
        
        if(response.ok)
            return await response.json();
        else if(response.status === 400 || response.status === 401)
            throw await response.text()
        else
            throw "Unknown error";
    }

    getCurrentUser() {
        return JSON.parse(localStorage.getItem('user'));
    }
}

export default new SensorsService();