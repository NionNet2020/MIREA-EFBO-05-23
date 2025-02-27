const express = require('express');
const path = require('path');
const app = express();
const port = 3000;

// Статические файлы
app.use(express.static(path.join(__dirname, 'public')));

// Главная страница
app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname, 'index.html'));
});

// Страница ошибки 404
app.use((req, res) => {
  res.status(404).sendFile(path.join(__dirname, '404.html'));
});

app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
