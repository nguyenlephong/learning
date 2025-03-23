package com.learning.webmana.poc.controller;

import com.learning.webmana.poc.service.ZipService;
import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.media.Content;
import io.swagger.v3.oas.annotations.media.Schema;
import io.swagger.v3.oas.annotations.tags.Tag;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.util.List;

@RestController
@RequestMapping("/api/zip")
@Tag(name = "ZIP API", description = "API for compressing and extracting files")
public class ZipController {

    private final ZipService zipService;

    public ZipController(ZipService zipService) {
        this.zipService = zipService;
    }

    @PostMapping("/compress")
    @Operation(summary = "Zip multiple files", description = "Uploads multiple files and returns a zip file")
    public ResponseEntity<byte[]> zipFiles(@RequestParam("files") List<MultipartFile> files) throws IOException {
        ByteArrayOutputStream zipStream = zipService.createZip(files);

        return ResponseEntity.ok()
                .header(HttpHeaders.CONTENT_DISPOSITION, "attachment; filename=files.zip")
                .body(zipStream.toByteArray());
    }

    @PostMapping("/extract")
    @Operation(summary = "Unzip a file", description = "Uploads a zip file and extracts its contents")
    public ResponseEntity<List<String>> unzipFile(@RequestParam("file") MultipartFile file) throws IOException {
        List<String> extractedFiles = zipService.extractZip(file);
        return ResponseEntity.ok(extractedFiles);
    }
}