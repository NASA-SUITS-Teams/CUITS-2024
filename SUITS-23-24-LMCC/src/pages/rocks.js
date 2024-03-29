import React, { useEffect } from 'react';
import './../pages-style/rocks.css';
import { populateRockData } from './../helpers/RockData.js';

function Rocks() {
  useEffect(() => {
    populateRockData(); // Pass the desired rock ID here
  }, []);

  return (

    <div>
      <h1>Geological Sampling</h1>
        <div className="rocks-container">
          { /* Maps Column on the left half */ }
          <div className="rocks-column">
            <div className="maps-container">
              <div className="subcontainer astronaut-loc-container">
                <h2>Astronaut Location</h2>
              </div>
              <div className="subcontainer sampling-map-container">
                <h2>Sample Map</h2>
              </div>
            </div>
            <div className="points-of-interest-container">
              <h2>Points of Interest</h2>
            </div>
          </div>
          { /* Rocks Column on the right half */ }
          <div className="rocks-column">
            <h2>Table of Rocks</h2>
            <div id="rockContainer"></div>
          
          </div>
        </div>
        <footer className="bottom-nav-container">
          
        </footer>
    </div>
  );
}

export default Rocks;
