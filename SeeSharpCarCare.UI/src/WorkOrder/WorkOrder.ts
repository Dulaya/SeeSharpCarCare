type TVehicle = {
    VIN: string
};

const url = "http://localhost:5299/";

export const getWorkOrders = async (): Promise<TVehicle[] | undefined> => {
    const endpoint = "api/workorder";

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

export const getWorkOrderById = async (id: number): Promise<TVehicle[] | undefined> => {
    const endpoint = `api/workorder/${id}`;

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

export const postWorkOrder = async (data: any): Promise<TVehicle[] | undefined> => {
    const endpoint = "api/workorder";
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

export const deleteWorkOrder = async (id: number): Promise<TVehicle[] | undefined> => {
    const endpoint = "api/workorder";
    try {
        const response = await fetch(`${url}${endpoint}/${id}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            throw new Error(`Response status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {

    }
}
