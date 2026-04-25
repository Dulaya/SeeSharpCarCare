import { useEffect, useState } from "react";
import { deleteTechnician, getTechnicians, postTechnician } from "./Technician";
import { CustomTd, CustomTh } from "../Components/CustomElements";


export const Technician = (props: { setCurrentModule: any }) => {
    const [techinician, setTechnicians] = useState<any>();
    const [name, setName] = useState("");
    const [id, setId] = useState("");

    useEffect(() => {
        getTechnicians().then((response: any) => {
            setTechnicians(response);
        });
    }, []);

    return <div style={{ border: "1px solid", display: "inline-block", padding: "10px" }}>
        <h2>Technicians</h2>
        <table>
            <thead>
                <tr >
                    <CustomTh>Id</CustomTh>
                    <CustomTh>Technician</CustomTh>
                    <CustomTh></CustomTh>
                </tr>
            </thead>
            <tbody >{techinician?.map((t: any) =>
                <tr>
                    <CustomTd>{t?.id}</CustomTd>
                    <CustomTd>{t?.name}</CustomTd>
                    <CustomTd><button onClick={() => {
                        deleteTechnician(t?.id).then(() =>
                            getTechnicians().then((response: any) => {
                                setTechnicians(response);
                            }))
                    }}>❌</button></CustomTd>
                </tr>)}
            </tbody>
        </table>
        <>
            <input placeholder="Id (e.g. TEC001)" value={id} onChange={(e) => setId(e.target.value)} /><br />
            <input placeholder="Name" value={name} onChange={(e) => setName(e.target.value)} /><br />
            <button type="submit"
                onClick={() => {
                    const data = { name, id }
                    props.setCurrentModule("Technician");
                    postTechnician(data).then(() => {
                        getTechnicians().then((response: any) => {
                            setTechnicians(response);
                        })
                    })
                }}
            >Add Technician</button>
        </>
    </div>
}