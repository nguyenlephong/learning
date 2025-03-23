package com.learning.webmana.poc.service;

import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardCopyOption;
import java.util.*;
import java.util.zip.*;

@Service
public class ZipService {

    public ByteArrayOutputStream createZip(List<MultipartFile> files) throws IOException {
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        try (ZipOutputStream zipOut = new ZipOutputStream(byteArrayOutputStream)) {
            for (MultipartFile file : files) {
                ZipEntry zipEntry = new ZipEntry(Objects.requireNonNull(file.getOriginalFilename()));
                zipOut.putNextEntry(zipEntry);
                zipOut.write(file.getBytes());
                zipOut.closeEntry();
            }
        }
        return byteArrayOutputStream;
    }

    public List<String> extractZip(MultipartFile zipFile) throws IOException {
        List<String> extractedFileNames = new ArrayList<>();
        try (ZipInputStream zipIn = new ZipInputStream(zipFile.getInputStream())) {
            ZipEntry entry;
            while ((entry = zipIn.getNextEntry()) != null) {
                String fileName = entry.getName();
                Path filePath = Files.createTempFile("unzipped_", fileName);
                Files.copy(zipIn, filePath, StandardCopyOption.REPLACE_EXISTING);
                extractedFileNames.add(filePath.toString());
                zipIn.closeEntry();
            }
        }
        return extractedFileNames;
    }
}