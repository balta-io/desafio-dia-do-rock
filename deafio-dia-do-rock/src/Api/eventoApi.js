const url = `http://localhost:${process.env.REACT_APP_DB_SERVER_PORT}/eventos`;

export async function getAll() {
    const response = await fetch(url);
    return response.json();
}

export async function getById(id) {
    const response = await fetch(`${url}/${id}`);
    return response.json();
}

export async function create(evento) {
    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(evento)
    });
    return response.json();
}

export async function update(id, evento) {
    const response = await fetch(`${url}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(evento)
    });
    return response.json();
}

export async function destroy(id) {
    const response = await fetch(`${url}/${id}`, {
        method: 'DELETE'
    });
    return response.json();
}

