import { useEffect, useState } from "react";
import { get, post, deleteById } from "../API/API";
import { CustomTd, CustomTh } from "../Components/CustomElements";


export const Customer = (props: { setCurrentModule: any }) => {
    const [customers, setCustomers] = useState<any>();
    const [customerName, setCustomerName] = useState<string>("");
    const [phone, setPhone] = useState<string>();
    const [address, setAddress] = useState<string>();
    const [email, setEmail] = useState<string>();

    useEffect(() => {
        get("customer").then((response: any) => {
            setCustomers(response);
        });
    }, []);

    return <div style={{ border: "1px solid", display: "inline-block", padding: "10px" }}>
        <h2>Customers</h2>
        <table>
            <thead>
                <tr >
                    <CustomTh>Id</CustomTh>
                    <CustomTh>Name</CustomTh>
                    <CustomTh>Phone</CustomTh>
                    <CustomTh>Email</CustomTh>
                    <CustomTh>Address</CustomTh>
                    <CustomTh></CustomTh>
                </tr>
            </thead>
            <tbody >{customers?.map((c: any) =>
                <tr>
                    <CustomTd>{c?.id}</CustomTd>
                    <CustomTd>{c?.customerName}</CustomTd>
                    <CustomTd>{c?.phone}</CustomTd>
                    <CustomTd>{c?.email}</CustomTd>
                    <CustomTd>{c?.address}</CustomTd>
                    <CustomTd><button onClick={() => {
                        deleteById({ id: c?.id, name: "customer" }).then(() =>
                            get("customer").then((response: any) => {
                                setCustomers(response);
                            }))
                    }}>❌</button></CustomTd>
                </tr>)}
            </tbody>
        </table>
        <>
            <input placeholder="Name" value={customerName} onChange={(e) => setCustomerName(e.target.value)} /><br />
            <input placeholder="Phone" value={phone} onChange={(e) => setPhone(e.target.value)} /><br />
            <input placeholder="Address" value={address} onChange={(e) => setAddress(e.target.value)} /><br />
            <input placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)} /><br />
            <button type="submit"
                disabled={customerName?.length > 0 ? false : true}
                onClick={() => {
                    const data = { customerName, phone, address, email }
                    props.setCurrentModule("Customer");
                    post({ data, name: "customer" }).then(() => {
                        get("customer").then((response: any) => {
                            setCustomers(response);
                        })
                    })
                }}
            >Add Customer</button>
        </>
    </div>
}