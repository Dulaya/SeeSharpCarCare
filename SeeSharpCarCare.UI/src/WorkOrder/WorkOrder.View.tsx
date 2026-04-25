import { useEffect, useState } from "react";
import { CustomTd, CustomTh } from "../Components/CustomElements";
import { deleteWorkOrder, getWorkOrderById, getWorkOrders, postWorkOrder } from "./WorkOrder";



export const WorkOrder = (props: { setCurrentModule: any }) => {

    const [workOrders, setWorkOrders] = useState<any>();
    const [vin, setVin] = useState("");
    const [make, setMake] = useState("");
    const [model, setModel] = useState("");
    const [year, setYear] = useState("");
    const [workOrder, setWorkOrder] = useState<any>();

    useEffect(() => {
        getWorkOrders().then((response: any) => {
            setWorkOrders(response);
        });
    }, []);

    console.log(workOrder);

    return <div style={{ border: "1px solid", display: "inline-block", padding: "10px" }}>
        <h2>Work Orders</h2>
        <table>
            <thead>
                <tr>
                    <CustomTh>Work Order Id</CustomTh>
                    <CustomTh>VIN</CustomTh>
                    <CustomTh>Customer</CustomTh>
                    <CustomTh>Details</CustomTh>
                    <CustomTh>Remove</CustomTh>
                </tr>
            </thead>
            <tbody >{workOrders?.map((wo: any) =>
                <tr>
                    <CustomTd>{wo?.id}</CustomTd>
                    <CustomTd>{wo?.vin}</CustomTd>
                    <CustomTd>{wo?.customer}</CustomTd>
                    <CustomTd><button onClick={() => {
                        getWorkOrderById(wo?.id)?.then((res: any) => {
                            setWorkOrder(res);
                        })

                    }}>Details</button></CustomTd>
                    <CustomTd><button onClick={() => {
                        deleteWorkOrder(wo?.id).then(() =>
                            getWorkOrders().then((response: any) => {
                                setWorkOrders(response);
                            }))
                    }}>❌</button></CustomTd>
                </tr>)}

            </tbody>
        </table>
        <div style={{ marginTop: "50px", border: "1px solid", padding: "5px" }}>
            <h3>Work Order Detais</h3>
            <div>Work Order Id: {workOrder?.id} </div>
            <div>VIN: {workOrder?.vin}</div>
            <div>Date: {workOrder?.repairDate}</div>
            <div>Customer: {workOrder?.customer}</div>
        </div>
        <table>
            <thead>
                <tr>
                    <CustomTh>Repair Id</CustomTh>
                    <CustomTh>Code</CustomTh>
                    <CustomTh>Details</CustomTh>
                    <CustomTh>Cost</CustomTh>
                    <CustomTh>Tech Id</CustomTh>
                    <CustomTh>Tech Name</CustomTh>
                </tr>
            </thead>
            <tbody>
                {
                    workOrder?.repairs?.map((repair: any) => {
                        return <tr>
                            <CustomTd>{repair?.id}</CustomTd>
                            <CustomTd> {repair?.repairCode}</CustomTd>
                            <CustomTd> {repair?.details}</CustomTd>
                            <CustomTd>${repair?.cost}</CustomTd>
                            <CustomTd>{repair?.technician?.id}</CustomTd>
                            <CustomTd>{repair?.technician?.name}</CustomTd>
                        </tr>
                    })
                }
            </tbody>
        </table>
        <>
            <input name="query" placeholder="VIN" value={vin} onChange={(e) => setVin(e.target.value)} maxLength={17} />{vin.length > 0 && vin.length}<br />
            <button type="submit"
                onClick={() => {
                    const data = {
                        vin
                    }
                    postWorkOrder(data).then(() =>
                        getWorkOrders().then((response: any) => {
                            setWorkOrders(response);
                        })
                    )
                    props.setCurrentModule("WorkOrder");
                }}
            >Add Work Order</button>
        </>
    </div>
}
