// RainTable component -> shows the rain days in a table
function RainTable({ days }) {
    return (
        <table>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Rain (mm)</th>
                    <th>Rain hours</th>
                </tr>
            </thead>
            <tbody>
                {days.map(day => (
                    <tr key={day.id}>
                        <td>{day.date}</td>
                        <td>{day.millimeters}</td>
                        <td>{day.rainHours}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}

// Lets App use the RainTable
export default RainTable
