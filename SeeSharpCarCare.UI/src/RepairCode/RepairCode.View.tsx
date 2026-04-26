import { useEffect, useState } from "react";
import { CustomTd, CustomTh } from "../Components/CustomElements";
import { get } from "../API/API";



export const RepairCode = (props: { setCurrentModule: any }) => {

    const [repairCodes, setRepairCodes] = useState<any>();

    useEffect(() => {
        get("repairCode").then((response: any) => {
            setRepairCodes(response);
        });
    }, []);


    return <div style={{ border: "1px solid", display: "inline-block", padding: "10px" }}>
        <h2>Repair Codes</h2>
        <table style={{ width: "750px" }}>
            <thead>
                <tr>
                    <CustomTh>Repair Code</CustomTh>
                    <CustomTh>Repair Name</CustomTh>
                </tr>
            </thead>
            <tbody >{repairCodes?.map((rc: any) =>
                <tr>
                    <CustomTd>{rc?.id}</CustomTd>
                    <CustomTd>{rc?.repairName}</CustomTd>
                </tr>)}

            </tbody>
        </table>
    </div>
}
