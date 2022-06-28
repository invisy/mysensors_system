import React from 'react';
import { Link } from 'react-router-dom';

const Unauthorized = () => (
    <div>
        <h1>401 - Unauthorized!</h1>
        <Link to="/">
            Go Home
        </Link>
    </div>
);

export default Unauthorized;