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
        let result = { status: null, data: null };
        let auth = authHeader();
        const response = await fetch("/api/sensors/add", {
            method: 'POST',
            body: JSON.stringify(sensor),
            headers: {
                'Content-Type': 'application/json',
                ...auth
            }
        });

        result.status = response.status;
        if (!response.ok)
            result.data = await response.text();

        return result;
    }

    async removeSensorById(id) {
        let result = { status: null, data: null};
        let auth = authHeader();
        const response = await fetch("/api/sensors/" + id, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                ...auth
            }
        });

        result.status = response.status;
        if(response.ok)
        result.data = "";

        return result;
    }

    async getToken(id) {
        let result = { status: null, data: null};
        let auth = authHeader();
        const response = await fetch("/api/sensors/token/" + id, {
            headers: {
                'Content-Type': 'application/json',
                ...auth
            }
        });

        result.status = response.status;
        if(response.ok)
            result.data = await response.json();
        else
            result.data = await response.text();
        
        return result;
    }

    async getParametersBySensorId(id) {
        let result = { status: null, data: null};
        let auth = authHeader();
        const response = await fetch("/api/sensorParameters/sensor/" + id, {
            headers: {
                'Content-Type': 'application/json',
                ...auth
            }
        });

        result.status = response.status;
        if(response.ok)
            result.data = await response.json();
        else
            result.data = await response.text();

        return result;
    }

    async getValuesByParameterId(id, periodInSeconds) {
        let result = { status: null, data: null};
        let auth = authHeader();
        const response = await fetch("/api/sensorData/" + id + "/" + periodInSeconds, {
            headers: {
                'Content-Type': 'application/json',
                ...auth
            }
        });

        result.status = response.status;
        if(response.ok)
            result.data = await response.json();
        else
            result.data = await response.text();

        return result;
    }
}

export default new SensorsService();