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

    async addSensor(sensor) {
        let auth = authHeader();
        const response = await fetch("/api/sensors/add", {
            method: 'POST',
            body: JSON.stringify(sensor),
            headers: {
                'Content-Type': 'application/json',
                ...auth
            }
        });

        if(response.ok)
            return response.ok;
        else if(response.status === 400 || response.status === 401)
            throw await response.text()
        else
            throw "Unknown error";
    }
}

export default new SensorsService();