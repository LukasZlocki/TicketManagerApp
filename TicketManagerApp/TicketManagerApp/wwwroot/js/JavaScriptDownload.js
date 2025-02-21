window.downloadFileFromBytes = (fileName, bytesBase64) => {
    const link = document.createElement('a');
    link.href = `data:application/octet-stream;base64,${bytesBase64}`;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};
