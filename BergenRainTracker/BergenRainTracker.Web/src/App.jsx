// What to do next session (1 hour ish):
// 1. Run git status (should be on feature/react-frontend branch, clean). Start Docker Desktop + docker compose up -d.
// 2. Start the API in Visual Studio with Select Startup Item (green arrow) and React (npm.cmd run dev) in Developer Powershell, check that the table and chart show on the page.
// 3. Add a button in App that sends a POST request to the API to fetch new rain data and update the table and chart. Commit and push in Developer Powershell.
// 4. If time: clean up the demo CSS, center the page, and style the table, chart, and button. Commit and push.


import { useEffect, useState } from 'react'
import './App.css'
import RainTable from './RainTable'
import RainChart from './RainChart'

// App component file -> what's shown on the page (JSX)
function App() {
    // Rain data (starts as an empty list), rainDays stores it, and setRainDays changes it
    const [rainDays, setRainDays] = useState([])
    // True while new rain data is being fetched -> stops double clicks
    const [isLoading, setIsLoading] = useState(false)
    // Gets the rain data from the API when the page loads and saves it in rainDays
    useEffect(() => {
        fetch('https://localhost:7196/api/rain').then(response => response.json()).then(data => setRainDays(data))
    }, [])
    // Asks the API to fetch new rain data -> then gets the updated list
    async function fetchNewRainData() {
        setIsLoading(true)
        try {
            await fetch('https://localhost:7196/api/rain/fetch', { method: 'POST' })
            const response = await fetch('https://localhost:7196/api/rain')
            const data = await response.json()
            setRainDays(data)
        } finally {
            setIsLoading(false)
        }
    }

    return (
        <main>
            <h1>Bergen Rain Tracker</h1>
            {/* Button that fetches new rain data, turns off and shows "Fetching..." until it's done */}
            <button onClick={fetchNewRainData} disabled={isLoading}>{isLoading ? 'Fetching...' : 'Fetch new rain data'}</button>
            {/* Shows the rain table and chart, sends rainDays to both as days */}
            <RainTable days={rainDays} />
            <RainChart days={rainDays} />
        </main>
    )
}

// Lets main.jsx use App
export default App
