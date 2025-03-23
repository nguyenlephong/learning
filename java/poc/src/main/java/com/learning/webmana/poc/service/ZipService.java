package com.learning.webmana.poc.service;

import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardCopyOption;
import java.util.*;
import java.util.zip.*;

@Service
public class ZipService {

    private static final Logger logger = LoggerFactory.getLogger(ZipService.class);


    public ByteArrayOutputStream createZip(List<MultipartFile> files) throws IOException {
        logger.info("Starting ZIP compression...");

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        try (ZipOutputStream zipOut = new ZipOutputStream(baos)) {
            for (MultipartFile file : files) {
                logger.debug("Adding file: {}", file.getOriginalFilename());
                ZipEntry zipEntry = new ZipEntry(file.getOriginalFilename());
                zipOut.putNextEntry(zipEntry);
                zipOut.write(file.getBytes());
                zipOut.closeEntry();
            }
        } catch (IOException e) {
            logger.error("Error during ZIP processing", e);
            throw e;
        }

        logger.info("ZIP file created successfully.");
        return baos;
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