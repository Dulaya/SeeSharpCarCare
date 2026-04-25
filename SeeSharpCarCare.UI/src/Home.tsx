import { useState } from "react"
import { Vehicle } from "./Vehicle/Vehicle.view";
import { WorkOrder } from "./WorkOrder/WorkOrder.View";

export const Home = () => {
    const [currentModule, setCurrentModule] = useState<string>("Vehicle");

    return <div style={{ textAlign: "center" }}>
        <img style={{ height: "150px" }} src={"./src/assets/logo.png"} />
        <div style={{ border: "1px solid", margin: "25px 0" }}>
            <button onClick={() => {
                setCurrentModule("Vehicle");
            }}>Vehicles</button>
            <button onClick={() => {
                setCurrentModule("WorkOrder");
            }}>Work Orders</button>
        </div>
        {currentModule == "Vehicle" && <Vehicle setCurrentModule={setCurrentModule} />}
        {currentModule == "WorkOrder" && <WorkOrder setCurrentModule={setCurrentModule} />}
    </div>

}