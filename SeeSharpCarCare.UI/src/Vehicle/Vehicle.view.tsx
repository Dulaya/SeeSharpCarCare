import { useEffect, useState } from "react";
import { deleteVehicle, getVehicles, postVehicle } from "./Vehicle";
import { CustomTd, CustomTh } from "../Components/CustomElements";

type TVehicle = {
    VIN: string,
    name: string,
    make: string,
    year: number
};


export const Vehicle = (props: { setCurrentModule: any }) => {
    const [vehicles, setVehicles] = useState<TVehicle[] | undefined>();
    const [vin, setVin] = useState("");
    const [make, setMake] = useState("");
    const [model, setModel] = useState("");
    const [year, setYear] = useState("");

    useEffect(() => {
        getVehicles().then((response: any) => {
            console.log(response);
            setVehicles(response);
        });
    }, []);

    return <div style={{ border: "1px solid", display: "inline-block", padding: "10px" }}>
        <h2>Vehicles</h2>
        <table>
            <thead>
                <tr >
                    <CustomTh>VIN</CustomTh>
                    <CustomTh>Make</CustomTh>
                    <CustomTh>Model</CustomTh>
                    <CustomTh>Year</CustomTh>
                    <CustomTh>Remove</CustomTh>
                </tr>
            </thead>
            <tbody >{vehicles?.map((v: any) =>
                <tr>
                    <CustomTd>{v?.vin}</CustomTd>
                    <CustomTd>{v?.make}</CustomTd>
                    <CustomTd>{v?.model}</CustomTd>
                    <CustomTd>{v?.year}</CustomTd>
                    <CustomTd><button onClick={() => {
                        deleteVehicle(v?.vin).then(() =>
                            getVehicles().then((response: any) => {
                                setVehicles(response);
                            }))
                    }}>❌</button></CustomTd>
                </tr>)}
            </tbody>
        </table>
        <>
            <input name="query" placeholder="VIN" value={vin} onChange={(e) => setVin(e.target.value)} maxLength={17} />{vin.length > 0 && vin.length}<br />
            <input name="query" placeholder="Make" value={make} onChange={(e) => setMake(e.target.value)} /><br />
            <input name="query" placeholder="Model" value={model} onChange={(e) => setModel(e.target.value)} /><br />
            <input name="query" placeholder="Year" value={year} onChange={(e) => setYear(e.target.value)} /><br />
            <button type="submit"
                onClick={() => {
                    const data = {
                        vin,
                        make,
                        model,
                        year
                    }
                    props.setCurrentModule("Vehicle");
                    postVehicle(data).then(() => {
                        getVehicles().then((response: any) => {
                            setVehicles(response);
                        })
                    })
                }}
            >Add Vehicle</button>
        </>
    </div>
}