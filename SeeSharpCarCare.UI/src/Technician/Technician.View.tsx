import { useEffect, useState } from "react";
import { get, post, deleteById } from "../API/API";
import { CustomTd, CustomTh } from "../Components/CustomElements";


export const Technician = (props: { setCurrentModule: any }) => {
    const [techinician, setTechnicians] = useState<any>();
    const [name, setName] = useState("");
    const [id, setId] = useState("");

    useEffect(() => {
        get("technician").then((response: any) => {
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
                        deleteById({ id: t?.id, name: "technician" }).then(() =>
                            get("technician").then((response: any) => {
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
                disabled={id.length && name.length > 0 ? false : true}
                onClick={() => {
                    const data = { name, id }
                    props.setCurrentModule("Technician");
                    post({ data, name: "technician" }).then(() => {
                        get("technician").then((response: any) => {
                            setTechnicians(response);
                        })
                    })
                }}
            >Add Technician</button>
        </>
    </div>
}