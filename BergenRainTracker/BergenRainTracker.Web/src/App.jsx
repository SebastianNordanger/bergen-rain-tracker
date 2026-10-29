// App component file -> what's shown on the page (JSX)
import { useEffect, useState } from 'react'
import RainTable from './RainTable'
import RainChart from './RainChart'

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
            <p>Historical daily rain data for Bergen sentrum (only finished days, not live)</p>
            {/* Button that fetches new rain data, turns off and shows "Fetching..." until it's done */}
            <button onClick={fetchNewRainData} disabled={isLoading}>{isLoading ? 'Fetching...' : 'Fetch new rain data'}</button>
            {/* Shows the rain chart and table, sends rainDays to both as days */}
            <RainChart days={rainDays} />
            <RainTable days={rainDays} />
            {/* Open-Meteo credit (needed by their license) */}
            <p>Weather data by <a href="https://open-meteo.com/">Open-Meteo.com</a></p>
        </main>
    )
}

// Lets main.jsx use App
export default App
