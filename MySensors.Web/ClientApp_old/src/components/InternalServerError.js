import React from 'react';
import { Link } from 'react-router-dom';

const InternalServerError = () => (
    <div>
        <h1>500 - Internal Server error</h1>
        <Link to="/">
            Go Home
        </Link>
    </div>
);

export default InternalServerError;