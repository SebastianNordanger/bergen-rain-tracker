// RainChart component file -> shows the rain per day in a bar chart
import { BarChart, Bar, XAxis, YAxis, Tooltip } from 'recharts'

function RainChart({ days }) {
    return (
        <BarChart width={800} height={300} data={days}>
            <XAxis dataKey="date" />
            <YAxis />
            <Tooltip />
            <Bar dataKey="millimeters" fill="#4a90d9" />
        </BarChart>
    )
}

// Lets App use the RainChart
export default RainChart
