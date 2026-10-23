// What to do next session (1 hour ish):
// 1. git status (should be on feature/react-frontend branch, clean). Start Docker Desktop + docker compose up -d.
// 2. Run the API in Visual Studio with Select Startup Item (green arrow) and React (npm.cmd run dev) in Developer Powershell, check that the data still shows in the browser console (F12).
// 3. Save the rain data in React (useState) instead of only printing it with console.log.
// 4. Show it in a table in a new component (RainTable.jsx). Commit and push in Developer Powershell.


import { useEffect } from 'react'
import './App.css'

// App component -> what's shown on the page (JSX)
function App() {
    // Gets the rain data from the API when the page loads and prints it in the browser console (F12)
    useEffect(() => {
        fetch('https://localhost:7196/api/rain').then(response => response.json()).then(data => console.log(data))
    }, [])

    return (
        <main>
            <h1>Bergen Rain Tracker</h1>
        </main>
    )
}

// Lets main.jsx use the App
export default App
