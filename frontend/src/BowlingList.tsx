import { useEffect, useState } from 'react';
import { bowl } from './types/bowl';

function BowlingList() {
  const [bowlers, setBowlers] = useState<bowl[]>([]);

  useEffect(() => {
    const fetchBowler = async () => {
      const response = await fetch('http://localhost:4000/Bowling');
      const data = await response.json();
      setBowlers(data);
    };
    fetchBowler();
  }, []);

  return (
    <>
      <h1>Bowlers</h1>
      <table>
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((b) => (
            <tr key={b.bowlerId}>
              <td>{b.bowlerName}</td>
              <td>{b.teamName}</td>
              <td>{b.address}</td>
              <td>{b.city}</td>
              <td>{b.state}</td>
              <td>{b.zip}</td>
              <td>{b.phoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlingList;
