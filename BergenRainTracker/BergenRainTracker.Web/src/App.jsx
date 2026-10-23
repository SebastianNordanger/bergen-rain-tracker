import { useEffect } from 'react'
import './App.css'

// App component -> what's shown on the page (JSX)
function App() {
    // Gets the rain data from the API when the page loads and prints it in the console
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
