export const getTechnicians = async () => {
const url = "http://localhost:5299/";
  
  try {
    const response = await fetch(url);
    
    // Check if response is OK (status in range 200-299)
    if (!response.ok) {
      throw new Error(`Response status: ${response.status}`);
    }

    const data = await response.json();
    console.log(data);
  } catch (error) {
  //  console.error('Fetch error:', error.message);
  }
}

getTechnicians();