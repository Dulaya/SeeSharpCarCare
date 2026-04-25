

const url = "http://localhost:5299/";

export const get = async (name: string) => {
    const endpoint = `api/${name}`;

    try {
        const response = await fetch(`${url}${endpoint}`);

        if (!response.ok) {
            throw new Error(`Response status: ${response.status}`);
        }

        const data = await response.json();
        return data;
    } catch (error) {
        throw alert(error);
    }
}

export const getById = async (body: {id: number, name: string}) => {
    const endpoint = `api/${body.name}/${body.id}`;

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

export const post = async (body: { name: string, data: any }) => {
    const endpoint = `api/${body.name}`;
    try {
        const response = await fetch(`${url}${endpoint}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(body.data)
        });

        if (!response.ok) {
            throw new Error(`Response status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        throw alert(error);
    }
}

export const deleteById = async (body: {id: string | number, name: string}) => {
    const endpoint = `api/${body.name}`;
    try {
        const response = await fetch(`${url}${endpoint}/${body.id}`, {
            method: "DELETE",
        });

        if (!response.ok) {
            throw new Error(`Response status: ${response.status}`);
        }

        return null; //await response.json();
    } catch (error) {
        throw alert(error);
    }
}
