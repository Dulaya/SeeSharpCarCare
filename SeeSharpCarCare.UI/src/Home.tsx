import { useState } from "react"
import { Vehicle } from "./Vehicle/Vehicle.view";
import { WorkOrder } from "./WorkOrder/WorkOrder.View";
import { Technician } from "./Technician/Technician.View";
import { Repair } from "./Repair/Repair.View";
import { Customer } from "./Customer/Customer.View";

export const Home = () => {
    const [currentModule, setCurrentModule] = useState<string>("Vehicle");

    return <div style={{ textAlign: "center" }}>
        <img style={{ height: "150px" }} src={"./src/assets/logo.png"} />
        <div style={{ border: "1px solid", margin: "25px 0" }}>
            <button onClick={() => {
                setCurrentModule("Vehicle");
            }}>Vehicles</button>
            <button onClick={() => {
                setCurrentModule("Customer");
            }}>Customer</button>
            <button onClick={() => {
                setCurrentModule("WorkOrder");
            }}>Work Orders</button>
            <button onClick={() => {
                setCurrentModule("Technician");
            }}>Technician</button>
            <button onClick={() => {
                setCurrentModule("Repair");
            }}>Repair</button>
        </div>
        {currentModule == "Vehicle" && <Vehicle setCurrentModule={setCurrentModule} />}
        {currentModule == "Customer" && <Customer setCurrentModule={setCurrentModule} />}
        {currentModule == "WorkOrder" && <WorkOrder setCurrentModule={setCurrentModule} />}
        {currentModule == "Technician" && <Technician setCurrentModule={setCurrentModule} />}
        {currentModule == "Repair" && <Repair setCurrentModule={setCurrentModule} />}
    </div>

}