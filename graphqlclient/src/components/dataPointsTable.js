// dataPointsTable.js
import React, { useState } from 'react';
import { gql, useQuery } from '@apollo/client';
import './DataPoints.css';

const GET_DATA_POINTS = gql`
  query GetDataPoints {
    dataPoints {
      Id
      DisplayName
      Description
    }
  }
`;

const DataPointTable = () => {
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);
  const { loading, error, data } = useQuery(GET_DATA_POINTS);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  const handleChangePage = (newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  // Calculate pagination
  const startIndex = page * rowsPerPage;
  const endIndex = startIndex + rowsPerPage;
  const paginatedData = data.dataPoints.slice(startIndex, endIndex);
  const totalPages = Math.ceil(data.dataPoints.length / rowsPerPage);

  return (
    <div className="table-container">
      <div className="table-controls">
        <select 
          value={rowsPerPage} 
          onChange={handleChangeRowsPerPage}
          className="rows-select"
        >
          <option value={10}>10 per page</option>
          <option value={20}>20 per page</option>
          <option value={30}>30 per page</option>
        </select>
      </div>

      <table className="data-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>MS Item ID</th>
            <th>Item Symbol</th>
            <th>Description</th>
            <th>Localization</th>
            <th>Vendor</th>
            <th>Update Frequency</th>
            <th>Timeliness</th>
            <th>Data Type</th>
            <th>Display Format</th>
            <th>Calc Raw Data</th>
            <th>Calc Desc</th>
          </tr>
        </thead>
        <tbody>
          {paginatedData.map((point) => (
            <tr key={point.Id}>
              <td>{point.Id}</td>
              <td>{point.DisplayName}</td>
              <td>{point.Description}</td>
              {/* Add other fields as needed */}
            </tr>
          ))}
        </tbody>
      </table>

      <div className="pagination">
        <button 
          onClick={() => handleChangePage(page - 1)}
          disabled={page === 0}
          className="page-button"
        >
          Previous
        </button>
        <span className="page-info">
          Page {page + 1} of {totalPages}
        </span>
        <button 
          onClick={() => handleChangePage(page + 1)}
          disabled={page >= totalPages - 1}
          className="page-button"
        >
          Next
        </button>
      </div>
    </div>
  );
};

export default DataPointTable;