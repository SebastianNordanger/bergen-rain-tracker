// What to do next session (1 hour ish):
// 1. Run git status (should be on feature/react-frontend branch, clean). Start Docker Desktop + docker compose up -d.
// 2. Start the API in Visual Studio with Select Startup Item (green arrow) and React (npm.cmd run dev) in Developer Powershell, check that the table shows on the page.
// 3. Install a chart package and make a new component file (RainChart.jsx) with a bar chart of the rain per day.
// 4. Show RainChart in App under the table. Commit and push in Developer Powershell.


import { useEffect, useState } from 'react'
import './App.css'
import RainTable from './RainTable'

// App component file -> what's shown on the page (JSX)
function App() {
    // Rain data (starts as an empty list), rainDays stores it, and setRainDays changes it
    const [rainDays, setRainDays] = useState([])
    // Gets the rain data from the API when the page loads and saves it in rainDays
    useEffect(() => {
        fetch('https://localhost:7196/api/rain').then(response => response.json()).then(data => setRainDays(data))
    }, [])

    return (
        <main>
            <h1>Bergen Rain Tracker</h1>
            {/* Shows the rain table, sends rainDays to it as days */}
            <RainTable days={rainDays} />
        </main>
    )
}

// Lets main.jsx use the App
export default App
