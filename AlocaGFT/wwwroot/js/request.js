async function getDataAsync(uri, headers = new Headers()) {
  let response = await fetch(uri);
  let data = await response.json();
  return data;
}

async function postDataAsync(
  uri,
  body,
  headers = {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
  returnJson = false
) {
  const response = await fetch(uri, {
    method: "POST",
    headers,
    body: JSON.stringify(body),
  });

  let result;
  if (returnJson) {
    result = await response.json();
  } else {
    result = await response.text();
  }

  return result;
}

export { getDataAsync, postDataAsync };
