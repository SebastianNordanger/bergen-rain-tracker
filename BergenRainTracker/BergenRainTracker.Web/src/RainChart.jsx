// RainChart component file -> shows the rain per day in a bar chart
import { BarChart, Bar, XAxis, YAxis, Tooltip, ResponsiveContainer } from 'recharts'

function RainChart({ days }) {
    return (
        <ResponsiveContainer width="100%" height={300}>
            <BarChart data={days} margin={{ bottom: 20 }}>
                <XAxis dataKey="date" label={{ value: 'Date', position: 'insideBottom', offset: -15, fill: '#666' }} />
                <YAxis unit=" mm" />
                <Tooltip contentStyle={{ background: '#1f2028', border: 'none' }} cursor={{ fill: '#2e303a' }} />
                <Bar dataKey="millimeters" name="Rain (mm)" fill="#4a90d9" />
            </BarChart>
        </ResponsiveContainer>
    )
}

// Lets App use the RainChart
export default RainChart
