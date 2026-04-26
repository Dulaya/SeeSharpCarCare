import { useEffect, useState } from "react";
import { get, post, deleteById } from "../API/API";
import { CustomTd, CustomTh } from "../Components/CustomElements";


export const Repair = (props: { setCurrentModule: any }) => {
    const [repairs, setRepairs] = useState<any>();
    const [workOrderId, setWorkOrderId] = useState<string>("");
    const [repairCode, setRepairCode] = useState<string>();
    const [technicianId, setTechnicianId] = useState<string>();
    const [cost, setCost] = useState<number>();
    const [mileage, setMileage] = useState<number>();
    const [details, setDetails] = useState<string>();

    useEffect(() => {
        get("repair").then((response: any) => {
            console.log(response);
            setRepairs(response);
        });
    }, []);

    return <div style={{ border: "1px solid", display: "inline-block", padding: "10px" }}>
        <h2>Repairs</h2>
        <table>
            <thead>
                <tr >
                    <CustomTh>Repair Id</CustomTh>
                    <CustomTh>WorkOrder Id</CustomTh>
                    <CustomTh>Repair Code</CustomTh>
                    <CustomTh>Technician</CustomTh>
                    <CustomTh>Cost</CustomTh>
                    <CustomTh>Mileage</CustomTh>
                    <CustomTh>Details</CustomTh>
                    <CustomTh></CustomTh>
                </tr>
            </thead>
            <tbody >{repairs?.map((r: any) =>
                <tr>
                    <CustomTd>{r?.id}</CustomTd>
                    <CustomTd>{r?.workOrderId}</CustomTd>
                    <CustomTd>{r?.repairCode}</CustomTd>
                    <CustomTd>{r?.technicianId}</CustomTd>
                    <CustomTd>{r?.cost}</CustomTd>
                    <CustomTd>{r?.mileage}</CustomTd>
                    <CustomTd>{r?.details}</CustomTd>
                    <CustomTd><button onClick={() => {
                        deleteById({ id: r?.id, name: "repair" }).then(() =>
                            get("repair").then((response: any) => {
                                setRepairs(response);
                            }))
                    }}>❌</button></CustomTd>
                </tr>)}
            </tbody>
        </table>
        <>
            <input placeholder="Work Order Id" value={workOrderId} onChange={(e) => setWorkOrderId(e.target.value)} /><br />
            <input placeholder="Repair Code" value={repairCode} onChange={(e) => setRepairCode(e.target.value)} /><br />
            <input placeholder="Technician Id" value={technicianId} onChange={(e) => setTechnicianId(e.target.value)} /><br />
            <input placeholder="Cost" value={cost} onChange={(e) => setCost(Number(e.target.value))} /><br />
            <input placeholder="Mileage" value={mileage} onChange={(e) => setMileage(Number(e.target.value))} /><br />
            <input placeholder="Details" value={details} onChange={(e) => setDetails(e.target.value)} /><br />
            <button type="submit"
                disabled={workOrderId?.length > 0 ? false : true}
                onClick={() => {
                    const data = {
                        workOrderId,
                        repairCode,
                        technicianId,
                        cost,
                        mileage,
                        details
                    }
                    props.setCurrentModule("Repair");
                    post({ data, name: "repair" }).then(() => {
                        get("repair").then((response: any) => {
                            setRepairs(response);
                        })
                    })
                }}
            >Add Repair</button>
        </>
    </div>
}