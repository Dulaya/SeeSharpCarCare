const url = "http://localhost:5299/";

export const getTechnicians = async () => {

  const endpoint = "api/technician";

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

export const postTechnician = async (data: any): Promise<any[] | undefined> => {
    const endpoint = "api/technician";
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

export const deleteTechnician = async (id: number) => {
    const endpoint = "api/technician";
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
