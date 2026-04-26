import { useEffect, useState } from "react";
import { CustomTd, CustomTh } from "../Components/CustomElements";
import { get, post, deleteById, getById } from "../API/API";



export const WorkOrder = (props: { setCurrentModule: any }) => {

    const [workOrders, setWorkOrders] = useState<any>();
    const [vin, setVin] = useState("");
    const [customerId, setCustomerId] = useState<number>();
    const [workOrderDetails, setWorkOrderDetails] = useState<any>();

    useEffect(() => {
        get("workorder").then((response: any) => {
            setWorkOrders(response);
        });
    }, []);


    return <div style={{ border: "1px solid", display: "inline-block", padding: "10px" }}>
        <h2>Work Orders</h2>
        <table style={{ width: "750px" }}>
            <thead>
                <tr>
                    <CustomTh>Work Order Id</CustomTh>
                    <CustomTh>VIN</CustomTh>
                    <CustomTh>Customer Id</CustomTh>
                    <CustomTh>Customer</CustomTh>
                    <CustomTh>Details</CustomTh>
                    <CustomTh>Remove</CustomTh>
                </tr>
            </thead>
            <tbody >{workOrders?.map((wo: any) =>
                <tr>
                    <CustomTd>{wo?.id}</CustomTd>
                    <CustomTd>{wo?.vin}</CustomTd>
                    <CustomTd>{wo?.customerId}</CustomTd>
                    <CustomTd>{wo?.customer?.customerName}</CustomTd>
                    <CustomTd><button onClick={() => {
                        getById({ id: wo?.id, name: "workorder" })?.then((res: any) => {
                            setWorkOrderDetails(res);
                        }).then(() => {
                            getById({ id: wo?.customerId, name: "customer" })?.then((res: any) => {
                                setWorkOrderDetails((details: any) => {
                                    const result: any = { ...details, ...res, workOrderId: wo?.id };
                                    console.log("result", result)
                                    return result;
                                });
                            })
                        })

                    }}>Details</button></CustomTd>
                    <CustomTd><button onClick={() => {
                        deleteById({ id: wo?.id, name: "workorder" }).then(() =>
                            get("workorder").then((response: any) => {
                                setWorkOrders(response);
                            }))
                    }}>❌</button></CustomTd>
                </tr>)}

            </tbody>
        </table>

        <div style={{marginTop: "25px"}}>
            <input placeholder="CustomerId" value={customerId} onChange={(e) => setCustomerId(Number(e.target.value))} /><br />
            <input placeholder="VIN" value={vin} onChange={(e) => setVin(e.target.value)} maxLength={17} />{vin.length > 0 && vin.length}<br />
            <button type="submit"
                onClick={() => {
                    const data = {
                        vin, customerId
                    }
                    post({ data, name: "workorder" }).then(() =>
                        get("workorder").then((response: any) => {
                            setWorkOrders(response);
                        })
                    )
                    props.setCurrentModule("WorkOrder");
                }}
            >Add Work Order</button>
        </div>

        <div style={{ marginTop: "50px", border: "1px solid", padding: "5px" }}>
            <h3>Work Order Details</h3>
            <div>Work Order Id: {workOrderDetails?.workOrderId} </div>
            <div>VIN: {workOrderDetails?.vin}</div>
            <div>Service Date: {workOrderDetails?.repairDate}</div>
            <div>Customer Id: {workOrderDetails?.id}</div>
            <div>Name: {workOrderDetails?.customerName}</div>
            <div>Phone: {workOrderDetails?.phone}</div>
            <div>Address: {workOrderDetails?.address}</div>
            <div>Email: {workOrderDetails?.email}</div>
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
                    <CustomTh>Mileage</CustomTh>
                </tr>
            </thead>
            <tbody>
                {
                    workOrderDetails?.repairs?.map((repair: any) => {
                        return <tr>
                            <CustomTd>{repair?.id}</CustomTd>
                            <CustomTd> {repair?.repairCode}</CustomTd>
                            <CustomTd> {repair?.details}</CustomTd>
                            <CustomTd>${repair?.cost}</CustomTd>
                            <CustomTd>{repair?.technician?.id}</CustomTd>
                            <CustomTd>{repair?.technician?.name}</CustomTd>
                            <CustomTd>{repair?.mileage}</CustomTd>
                        </tr>
                    })
                }
            </tbody>
        </table>
    </div>
}
