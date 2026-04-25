type TVehicle = {
    VIN: string
};

const url = "http://localhost:5299/";

export const getVehicles = async (): Promise<TVehicle[] | undefined> => {
    const endpoint = "api/vehicle";

    try {
        const response = await fetch(`${url}${endpoint}`);

        if (!response.ok) {
            throw new Error(`Response status: ${response.status}`);
        }

        const data = await response.json();
        return data;
    } catch (error) {
    }
}

export const postVehicle = async (data: any): Promise<TVehicle[] | undefined> => {
    const endpoint = "api/vehicle";
    try {
        const response = await fetch(`${url}${endpoint}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error(`Response status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {

    }
}

export const deleteVehicle = async (vin: string): Promise<TVehicle[] | undefined> => {
    const endpoint = "api/vehicle";
    try {
        const response = await fetch(`${url}${endpoint}/${vin}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            throw new Error(`Response status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {

    }
}
